using Octokit;

namespace QA.Drivers.Github;

public class GithubDriver
{
    private readonly GitHubClient _gitHubClient;

    public GithubDriver(GitHubClient gitHubClient)
    {
        _gitHubClient = gitHubClient;
    }

}