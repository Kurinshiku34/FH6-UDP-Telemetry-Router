using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FH6_UDPort_Forwarder {
    public partial class Form1 : Form {
        private AppSettings _settings;
        private string _settingsFilePath = "config.json";
        private CancellationTokenSource _cancellationTokenSource;
        private bool _isRunning = false;

        public Form1() {
            InitializeComponent();
            SetupContextMenus();
            LoadSettings();
        }

        private void SetupContextMenus() {
            ContextMenuStrip portMenu = new ContextMenuStrip();
            portMenu.Items.Add("Remove Selected", null, (s, e) => {
                if (lstPorts.SelectedIndex != -1) { lstPorts.Items.RemoveAt(lstPorts.SelectedIndex); SaveSettings(); }
            });
            lstPorts.ContextMenuStrip = portMenu;

            ContextMenuStrip exeMenu = new ContextMenuStrip();
            exeMenu.Items.Add("Remove Selected", null, (s, e) => {
                if (lstExes.SelectedIndex != -1) { lstExes.Items.RemoveAt(lstExes.SelectedIndex); SaveSettings(); }
            });
            lstExes.ContextMenuStrip = exeMenu;

            lstPorts.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Delete && lstPorts.SelectedIndex != -1) { lstPorts.Items.RemoveAt(lstPorts.SelectedIndex); SaveSettings(); }
            };

            lstExes.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Delete && lstExes.SelectedIndex != -1) { lstExes.Items.RemoveAt(lstExes.SelectedIndex); SaveSettings(); }
            };
        }

        private void LoadSettings() {
            if (File.Exists(_settingsFilePath)) {
                string json = File.ReadAllText(_settingsFilePath);
                _settings = JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
            }
            else { _settings = new AppSettings(); }

            txtForzaPort.Text = _settings.ForzaPort.ToString();
            txtGameExe.Text = _settings.GameExeName;
            chkAutoWatch.Checked = _settings.AutoWatch;

            foreach (var port in _settings.TargetPorts) lstPorts.Items.Add(port);
            foreach (var path in _settings.ExePaths) lstExes.Items.Add(path);
        }

        private void SaveSettings() {
            _settings.ForzaPort = int.TryParse(txtForzaPort.Text, out int fp) ? fp : 5300;
            _settings.GameExeName = txtGameExe.Text;
            _settings.AutoWatch = chkAutoWatch.Checked;

            _settings.TargetPorts.Clear();
            foreach (var item in lstPorts.Items) _settings.TargetPorts.Add(Convert.ToInt32(item));

            _settings.ExePaths.Clear();
            foreach (var item in lstExes.Items) _settings.ExePaths.Add(item.ToString());

            string json = JsonSerializer.Serialize(_settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_settingsFilePath, json);
        }

        private void Log(string message) {
            if (rtbLog.InvokeRequired) {
                rtbLog.Invoke(new Action(() => Log(message)));
                return;
            }
            rtbLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\n");
            rtbLog.ScrollToCaret();
        }

        // ==========================================
        // Tutorial Window
        // ==========================================
        private void BtnHelp_Click(object sender, EventArgs e) {
            string myPath = Application.ExecutablePath;
            string launchCode = $"start \"\" \"{myPath}\" && %command%";

            Form helpForm = new Form {
                Text = "Steam Automation Guide",
                Size = new System.Drawing.Size(480, 360),
                BackColor = System.Drawing.Color.FromArgb(18, 18, 22),
                ForeColor = System.Drawing.Color.White,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            TextBox txtTutorial = new TextBox {
                Multiline = true,
                ReadOnly = true,
                BackColor = System.Drawing.Color.FromArgb(18, 18, 22),
                ForeColor = System.Drawing.Color.LightGray,
                BorderStyle = BorderStyle.None,
                Dock = DockStyle.Fill,
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular),
                Text = "Steam Launch Options Guide:\r\n\r\n" +
                       "To make this program start automatically when you launch the game " +
                       "from Steam, follow these steps:\r\n\r\n" +
                       "1. Right-click on the Forza game in your Steam Library.\r\n" +
                       "2. Go to 'Properties' > 'General' tab.\r\n" +
                       "3. Scroll down to the 'Launch Options' box and paste the code below.\r\n\r\n" +
                       "The following code is generated specifically for your computer:\r\n" +
                       "----------------------------------------------------------\r\n" +
                       $"{launchCode}\r\n" +
                       "----------------------------------------------------------\r\n\r\n" +
                       "Tip: You only need to copy the code between the dashed lines."
            };

            Panel marginPanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(15) };
            marginPanel.Controls.Add(txtTutorial);
            helpForm.Controls.Add(marginPanel);

            helpForm.ShowDialog();
        }

        private void BtnAddPort_Click(object sender, EventArgs e) {
            if (int.TryParse(txtNewPort.Text, out int newPort) && !lstPorts.Items.Contains(newPort)) {
                lstPorts.Items.Add(newPort);
                txtNewPort.Clear();
                SaveSettings();
            }
        }

        private void BtnAddExe_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Applications (*.exe;*.bat)|*.exe;*.bat|All Files (*.*)|*.*" }) {
                if (ofd.ShowDialog() == DialogResult.OK && !lstExes.Items.Contains(ofd.FileName)) {
                    lstExes.Items.Add(ofd.FileName);
                    SaveSettings();
                }
            }
        }

        private async void BtnStart_Click(object sender, EventArgs e) {
            if (_isRunning) return;

            SaveSettings();
            LaunchPrograms();

            _isRunning = true;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            Log("Routing started...");

            _cancellationTokenSource = new CancellationTokenSource();

            try {
                await Task.Run(() => StartForwarding(_cancellationTokenSource.Token));
            }
            catch (OperationCanceledException) { Log("Routing stopped."); }
            catch (Exception ex) { Log($"Error occurred: {ex.Message}"); }
        }

        private void BtnStop_Click(object sender, EventArgs e) {
            if (!_isRunning) return;
            _cancellationTokenSource?.Cancel();
            _isRunning = false;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void GameWatcherTimer_Tick(object sender, EventArgs e) {
            if (chkAutoWatch.Checked && !string.IsNullOrWhiteSpace(txtGameExe.Text)) {
                string processName = txtGameExe.Text.Replace(".exe", "").Trim();
                bool isGameRunning = Process.GetProcessesByName(processName).Length > 0;

                if (isGameRunning && !_isRunning) {
                    Log($"Detected {processName} running! Auto-starting...");
                    BtnStart_Click(null, EventArgs.Empty);
                }
                else if (!isGameRunning && _isRunning) {
                    Log($"Detected {processName} closed. Auto-stopping...");
                    BtnStop_Click(null, EventArgs.Empty);
                }
            }
        }

        private void StartForwarding(CancellationToken token) {
            int forzaPort = _settings.ForzaPort;
            List<IPEndPoint> targetEndpoints = new List<IPEndPoint>();
            foreach (int port in _settings.TargetPorts) targetEndpoints.Add(new IPEndPoint(IPAddress.Loopback, port));

            using UdpClient listener = new UdpClient(forzaPort);
            using UdpClient sender = new UdpClient();

            Log($"Forza port ({forzaPort}) is listening.");
            Log($"Forwarding data to {targetEndpoints.Count} targets.");

            while (!token.IsCancellationRequested) {
                if (listener.Available > 0) {
                    IPEndPoint remoteEp = new IPEndPoint(IPAddress.Any, 0);
                    byte[] data = listener.Receive(ref remoteEp);
                    foreach (var endpoint in targetEndpoints) sender.Send(data, data.Length, endpoint);
                }
                else { Thread.Sleep(1); }
            }
        }

        private void LaunchPrograms() {
            foreach (string path in _settings.ExePaths) {
                if (File.Exists(path)) {
                    try {
                        Process.Start(new ProcessStartInfo { FileName = path, WorkingDirectory = Path.GetDirectoryName(path), UseShellExecute = true });
                        Log($"Started: {Path.GetFileName(path)}");
                    }
                    catch (Exception ex) { Log($"Error ({Path.GetFileName(path)}): {ex.Message}"); }
                }
                else {
                    Log($"Not found: {path}");
                }
            }
        }
    }

    public class AppSettings {
        public int ForzaPort { get; set; } = 5300;
        public string GameExeName { get; set; } = "forzahorizon6";
        public bool AutoWatch { get; set; } = false;
        public List<int> TargetPorts { get; set; } = new List<int>();
        public List<string> ExePaths { get; set; } = new List<string>();
    }
}