# Snipping_OCR

Snipping_OCR is a straightforward desktop screenshot OCR tool designed for the Windows platform. It utilizes the system's built-in screenshot tool for capturing images and PaddleOCRSharp for OCR recognition. The software supports OCR character recognition in both Chinese and English.

English | [简体中文](./README_zh.md)

The tool has been tested on Windows 10 and Windows 11. Please note that it does not support Windows 7.

<p align="center">
  <img src="./doc/6.png">
</p>

## Features

- Supports offline usage
- Recognizes Chinese and English characters
- Recognizes clipboard images
- Allows drag and drop

## Installation

You can download and unzip the software from the repository's Releases. No installation is required. We provide standalone versions for windows and versions dependent on the .NET6 framework. For the framework-dependent version, you need to install the [.NET8 runtime](https://dotnet.microsoft.com/zh-cn/download/dotnet/8.0).

## Usage

1. Double-click `Snipping_OCR.exe` to launch the software.
2. Minimizing the software will minimize it to the tray, while closing it will exit the software.
3. Use the `Ctrl + Tab` shortcut to initiate a screenshot.
4. If the shortcut cannot be used normally, you can use other software or the system's built-in screenshot tool “Win + Shift + S” to take a screenshot. Then, use the right-click menu "Recognize Clipboard" in the tray to perform OCR recognition.
5. You can drag and drop images into the left blank area for recognition.
6. After copying an image file, you can also use the right-click menu "Recognize Clipboard" in the tray to perform OCR recognition.