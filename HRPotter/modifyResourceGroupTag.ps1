Connect-AzAccount
$Tag = Read-Host -Prompt 'Input tag  name'
$Value = Read-Host -Prompt 'Input tag value'
Set-AzResourceGroup -Name resRashair -Tag @{ $Tag = $Value}