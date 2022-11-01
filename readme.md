# Guide to Kubernetes

Install kubernetes in Ubuntu or Windows with the appropriate instructions from the [official documentation](https://kubernetes.io/docs/tasks/tools/)

## Install `kubectl` on Ubuntu

```curl
curl -LO "https://dl.k8s.io/release/$(curl -L -s https://dl.k8s.io/release/stable.txt)/bin/linux/amd64/kubectl"
```

```curl
curl -LO https://dl.k8s.io/release/v1.25.0/bin/linux/amd64/kubectl
```

```bash
sudo install -o root -g root -m 0755 kubectl /usr/local/bin/kubectl
```

## Uninstall Kubernetes and especially minikube from Ubuntu

```bash
sudo rm -rf .kube
sudo rm -rf /usr/local/bin/kubectl
sudo rm -rf /usr/bin/minikube
```

## Install `minikube` on Ubuntu

Make sure you have `kubectl` installed. You can install kubectl according to the instructions in [Install and Set Up kubectl](https://kubernetes.io/docs/tasks/tools/install-kubectl-linux/).

```bash

```