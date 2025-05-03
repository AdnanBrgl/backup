$exePath = "C:\FULL\PATH\TO\TIA_Backup.exe"
$taskName = "TIA_Backup_Gunluk"
$triggerTime = "20:38"

Unregister-ScheduledTask -TaskName $taskName -Confirm:$false -ErrorAction SilentlyContinue

$action = New-ScheduledTaskAction -Execute $exePath
$trigger = New-ScheduledTaskTrigger -Daily -At $triggerTime
$principal = New-ScheduledTaskPrincipal -UserId "SYSTEM" -RunLevel Highest

Register-ScheduledTask -TaskName $taskName -Action $action -Trigger $trigger -Principal $principal

Write-Host "✅ Görev eklendi: $taskName"
