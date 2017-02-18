

declare -a arr=("eastasia" "southeastasia" "centralus" "eastus" 
"eastus2" "westus" "northcentralus" "southcentralus" "northeurope" "westeurope" 
"japanwest" 
"japaneast" "brazilsouth" "australiaeast" "australiasoutheast"
"southindia" "centralindia"
"canadacentral" "canadaeast"
"ukwest" 
"westcentralus"
"westus2"
"koreacentral"
"koreasouth"

 )
az login
az account set --subscription-id <id>
declare -a regions=(
    "northeurope" "westeurope"
)
container="files"
resourcegroup="speedstorageaccounts"

for i in "${regions[@]}"
do
    account_name="dcgspeed$i"
    echo "$i"
    echo "creating $account_name"
    az storage account create -l $i -n $account_name -g $resourcegroup --sku Standard_LRS
    echo "$account_name created"
    echo "creating container $container in $account_name"
    az storage container create -n $container --account-name $account_name
    echo "container created"
    echo "uploading blob"
    az storage blob upload --account-name $account_name -c $container -f 1MB.dat -n 1MB.dat
    echo "blob uploaded"
done


az login
az storage container create -n files --account-name dcgspeedwestus
az storage account create -l eastus -n dcgspeedeastus -g speedstorageaccounts --sku Standard_LRS
az storage account create -l southcentralus -n dcgspeedsouthcentralus -g speedstorageaccounts --sku Standard_LRS
dd if=/dev/zero of=1MB.dat  bs=1024  count=1024
az storage container create -n files --account-name dcgspeedwestus
az storage blob list --account-name dcgspeedcentralus -c files
az storage container create -n files --account-name dcgspeedwestus
az storage blob upload --account-name dcgspeedwestus -c files -f 1MB.dat -n 1MB.dat