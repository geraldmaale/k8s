# Guide to Kubernetes (k8s)

Install kubernetes in Ubuntu or Windows with the appropriate instructions from the [official documentation](https://kubernetes.io/docs/tasks/tools/)

There are several big names in the k8s world including:

* [Kubernetes](https://kubernetes.io/)
* [Minikube](https://minikube.sigs.k8s.io/docs/)
* [Canonical Microk8s](https://microk8s.io/)
* [Rancher k3s](https://k3s.io/)
* [Docker Desktop with Kubernetes](https://www.docker.com/products/kubernetes/)

## Getting Started with Kubernetes and Minikube

### Install `kubectl` on Ubuntu

```curl
curl -LO "https://dl.k8s.io/release/$(curl -L -s https://dl.k8s.io/release/stable.txt)/bin/linux/amd64/kubectl"
```

```curl
curl -LO https://dl.k8s.io/release/v1.25.0/bin/linux/amd64/kubectl
```

```bash
sudo install -o root -g root -m 0755 kubectl /usr/local/bin/kubectl
```

### Uninstall Kubernetes and especially minikube from Ubuntu

```bash
sudo rm -rf .kube
sudo rm -rf /usr/local/bin/kubectl
sudo rm -rf /usr/bin/minikube
```

### Install `minikube` on Ubuntu

Make sure you have `kubectl` installed. You can install kubectl according to the instructions in [Install and Set Up kubectl](https://kubernetes.io/docs/tasks/tools/install-kubectl-linux/).

```bash

```

## Getting Started with Rancher and k3s

Rancher has some interesting paradigms for k8s. It is a lightweight k8s distribution that is easy to install and manage. It is also a great way to get started with k8s.

This also comes bundled up with container management when using the Rancher UI.

### Installing Rancher Desktop

Rancher desktop provides a minimal k8s cluster and a UI for managing containers and k8s. This can be a perfect replacement for Docker Desktop.

[Rancher Desktop](https://docs.rancherdesktop.io/getting-started/installation) can be downloaded and installed on Windows, Mac and Linux.

### Installing k3s

k3s is a lightweight kubernetes distribution from Rancher which can be setup very fast and easy with high availability.

For more directions for the installation, follow the official [k3s documentation](https://docs.k3s.io/installation)

## Common kubectl Commands

* `kubectl get pods` - List all pods
* `kubectl get pods -o wide` - List all pods with more details
* `kubectl get pods -n development -o yaml` - List all pods in yaml format in development namespace
* `kubectl get pods -n development -o json` - List all pods in json format in development namespace
* `kubectl get svc` - List all services
* `kubectl get svc -n development` - List all services in development namespace
* `kubectl get deployments` - List all deployments
* `kubectl get deployments -n development` - List all deployments in development namespace
* `kubectl get nodes` - List all nodes
* `kubectl get nodes -o wide` - List all nodes with more details
* `kubectl get namespaces` - List all namespaces
* `kubectl get all` - List all resources
* `kubectl get all -n development` - List all resources in development namespace
* `kubectl get all -n development -o wide` - List all resources in development namespace with more details
* `kubectl get all --all-namespaces` - List all resources in all namespaces
* `kubectl get all --all-namespaces -o wide` - List all resources in all namespaces with more details
* `kubectl apply -f <filename>` - Create resources from a file
* `kubectl delete -f <filename>` - Delete resource from a file
* `kubectl cluster-info` - Display cluster information

## Kubernetes Cluster Management Tools

* [Lens](https://k8slens.dev/)
* [Portainer](https://docs.k3s.io/installation)
* [Rancher Desktop](https://docs.rancherdesktop.io/getting-started/installation)

## Pro Tips for Portainer

To add kubernetes cluster to portainer, you need to get the IP address of the kubernetes cluster. You can get this by running `kubectl cluster-info` in the terminal. The IP address will be in the output.

In addition, you need to add the port number to the IP address stated above. Define the IP address or name used to connect to the environment (the Kubernetes host) and specify the port if required (30778 when using NodePort; 9001 when using Load Balancer)

* NodePort Example: `172.24.25.124:30778`

* Load Balancer Example: `172.24.25.124:9001`

For more information, see [how to add k8s environments](https://docs.portainer.io/admin/environments/add/kubernetes)
