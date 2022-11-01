# --image-mirror-country string       Country code of the image mirror to be used. Leave empty to use the global one. For Chinese mainland users, set it to cn.
# --image-repository string           Alternative image repository to pull docker images from. This can be used when you have limited access to gcr.io. Set it to "auto" to let minikube decide one for you. For Chinese mainland users, you may use local gcr.io mirrors such as registry.cn-hangzhou.aliyuncs.com/google_containers
      
echo "Create a new k8s (windows) node with minikube"
echo "---------------------------------------------"
minikube start -p testcluster --driver=docker --nodes=3 --memory=4g --image-mirror-country=cn --image-repository=registry.cn-hangzhou.aliyuncs.com/google_containers --kubernetes-version=stable

# echo "Create a new k8s (linux) node with minikube"
# echo "-----------------------------------"
# minikube start --driver=kvm2 --memory=4g --image-mirror-country=cn --image-repository=registry.cn-hangzhou.aliyuncs.com/google_containers --kubernetes-version=stable

echo "Enable addons dashboard"
echo "--------------------"
minikube addons enable dashboard
minikube addons enable metrics-server

echo "Enable addons ingress"
echo "--------------------"
minikube addons enable ingress
minikube addons enable ingress-dns

# echo "Add dns entry for ingress"
# Add-DnsClientNrptRule -Namespace ".test" -NameServers "$(minikube ip)"
# Get-DnsClientNrptRule | Where-Object {$_.Namespace -eq '.test'} | Remove-DnsClientNrptRule -Force; Add-DnsClientNrptRule -Namespace ".test" -NameServers "$(minikube ip)"
