try {
    $path = Get-ChildItem -Path .\ConvertImageBase64.exe -Recurse
    Write-Host $path
    $str = -join('"', $path, '"', ' %1')
    $regPath = 'HKCU:\SOFTWARE\Classes\`*\shell'
    $ch = Test-Path -Path 'HKCU:\SOFTWARE\Classes\`*\shell\ConvertToBase64'
    if ($ch -eq "True") {
        Remove-Item -Path 'HKCU:\SOFTWARE\Classes\`*\shell\ConvertToBase64'
    }
    New-Item -Path 'HKCU:\SOFTWARE\Classes\`*\shell' -Name ConvertToBase64 -Value '取得Base64編碼' -ItemType String
    New-Item -Path 'HKCU:\SOFTWARE\Classes\`*\shell\ConvertToBase64' -Name command -Value $str -ItemType String
} catch {
    Write-Host error -ForegroundColor Red -BackgroundColor White
    Write-Host $Error[0] -ForegroundColor Red -BackgroundColor White
    Start-Sleep 3
}