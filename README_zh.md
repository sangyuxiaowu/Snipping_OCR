# Snipping_OCR

Snipping_OCR 是一个简单的桌面截图 OCR 工具，专为 Windows 平台设计。它使用系统自带的截图工具进行截图，并使用 PaddleOCRSharp 进行 OCR 识别。软件支持中英文的 OCR 字符识别。

[English](./README.md) | 简体中文

该工具已在 Windows 10 和 Windows 11 上进行过测试。请注意，它不支持 Windows 7。

<p align="center">
  <img src="./doc/6.png">
</p>

## 功能

- 支持离线使用
- 中英文字符识别
- 剪切板图片识别
- 支持拖拽
- 专注模式

## 安装

你可以在仓库的 Releases 下载并解压软件，无需安装。

## 使用

1. 双击 `Snipping_OCR.exe` 启动软件。
2. 最小化将软件最小化到托盘，关闭则为退出软件。
3. 使用快捷键 `Ctrl + Tab` 启动截图。
4. 如果快捷键无法正常使用，你可以使用其他软件或者系统自带的截图工具 “Win + Shift + S” 截图，然后在托盘使用右键菜单 “识别剪贴板” 来进行 OCR 识别。
5. 你可以将图片拖放到左边空白区域来识别。
6. 复制图片文件后，也可以在托盘使用右键菜单 “识别剪贴板” 来进行 OCR 识别。