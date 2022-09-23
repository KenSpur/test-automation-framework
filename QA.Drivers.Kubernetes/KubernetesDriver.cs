using k8s;
using k8s.Models;

namespace QA.Drivers.Kubernetes;

public class KubernetesDriver
{
    private readonly k8s.Kubernetes _kubernetes;

    public KubernetesDriver(k8s.Kubernetes kubernetes)
    {
        _kubernetes = kubernetes;
    }

    public async Task<IEnumerable<V1Namespace>> GetAllNamespacesAsync()
    {
        var namespaceList = await _kubernetes.CoreV1.ListNamespaceAsync();
        return namespaceList.Items;
    }
}