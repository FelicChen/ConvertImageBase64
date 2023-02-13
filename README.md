# ConvertImageBase64.Core
 
就一個可以直接拖曳圖片到WinForm裡，並直接轉換成Base64字串的程式。

---

2023/02/13 update
增加滑鼠右鍵選單快速轉換Base64字串

編譯之後執行regedit.ps1(debug或release資料夾裡面)
這支程式會寫入機碼
寫得很簡單，請自行修改😅

<img src="data:image/png;base64,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" />