# Forza Horizon 6 UDP Telemetry Router 🏎️📡

A lightweight, open-source Windows application built with C# and .NET 8.0 that acts as a UDP telemetry forwarder for Forza Horizon 6. 

By default, Forza games only allow sending telemetry data to a single IP/Port. This router bypasses that limitation by listening to the main Forza telemetry port and dynamically forwarding the data to multiple target ports simultaneously. It also includes an auto-start watcher and `.exe`/`.bat` app launcher.

## ✨ Features
* **Multi-Port Forwarding:** Send your Forza telemetry to SimHub, motion rigs, and custom dashboard apps all at the same time without port conflicts.
* **Smart Auto-Start/Stop:** Automatically starts routing and launches your selected companion apps when it detects the game process running, and stops when the game closes.
* **App Launcher:** Select your favorite `.exe` or `.bat` mods/tools to launch together with the telemetry routing.
* **Modern UI:** Clean, dark-themed interface with neon accents.
* **Save State:** All your ports, paths, and settings are automatically saved to a local `config.json` file.

## 🚀 How to Use (For Players)

### 1. In-Game Settings
1. Open Forza Horizon 6 and go to **Settings > HUD and Gameplay**.
2. Scroll down to the bottom.
3. Set **Data Out** to `ON`.
4. Set **Data Out IP Address** to `127.0.0.1`.
5. Set **Data Out IP Port** to `5300` (or your preferred main port).

### 2. App Settings
1. Download the latest `.exe` from the NexusMods page (or Releases tab).
2. Run the application.
3. Ensure the **Forza Main Port** matches the one in-game (e.g., `5300`).
4. Add your target ports (e.g., `5301` for SimHub, `5302` for another mod).
5. Configure those target apps to listen to the ports you just added.
6. Click **START ROUTING**.

### 🎮 Steam Auto-Launch (Optional)
You can configure Steam to automatically open this router when you launch Forza Horizon 6.
1. Right-click on Forza Horizon 6 in your Steam Library.
2. Go to **Properties > General**.
3. Paste the following code into the **Launch Options** box:
```text
   cmd /c start "" "C:\Path\To\Your\FH6_UDPort_Forwarder.exe" && %command%
```
*(Note: Replace `C:\Path\To\Your\...` with the actual path where you placed the router application).*

## 🛠️ How to Build (For Developers)
If you want to compile the source code yourself or contribute to the project:

1. Clone the repository.
2. Open the `.sln` file using **Visual Studio 2022**.
3. Ensure you have the **.NET 8.0 SDK** installed.
4. Build the project using the `Release` and `win-x64` configuration.
5. If you want a single executable without required runtime installations, set the deployment mode to `Self-contained` and check `Produce single file` in the publish settings.

## 📄 License
This project is open-source and available under the MIT License. Feel free to fork, modify, and use it in your own sim-racing projects!
