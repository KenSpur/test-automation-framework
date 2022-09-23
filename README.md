# test-automation-framework

## Technologies used

- [SpecFlow](https://specflow.org) BDD Test framework
- [dotnet 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) Developer platform
- [XUnit](https://xunit.net/) Unit testing tool
- [Selenium](https://www.selenium.dev/) Web driver
- [docker](https://www.docker.com/) Containerization
- [github actions](https://github.com/features/actions) CI/CD pipelines

## Getting started (run tests locally)
[Install dotnet](https://learn.microsoft.com/en-us/dotnet/core/install/windows?tabs=net60)

## Tests without prerequisites

Run tests not of category webdriver and kubernetes
```shell
dotnet test --filter "Category!=webdriver & Category!=kubernetes"
```

## Webdriver tests

[Install chrome](https://www.google.com/intl/nl/chrome/)

Run tests
```shell
dotnet test --filter "Category=webdriver"
```
## Tests against Kubernetes cluster (aks example)
- [Install az cli](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli)
- [Install Kubectl](https://kubernetes.io/docs/tasks/tools/)

Login
```shell
az login
```
List subscriptions
```shell
az account list
```
Set subscription
```shell
az account set --subscription <subscription-id>
```
Validate subscription
```shell
az account show
```
Configure kubectl
```shell
az aks get-credentials --resource-group <resource-group-name> --name <k8s-cluster-name>
```
Check config
```shell
kubectl config get-contexts
```
Run tests
```shell
dotnet test --filter Category=kubernetes
```