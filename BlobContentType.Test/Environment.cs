using System;

namespace BlobContentType.Test
{
    public class Environment
    {
        public Uri ApplicationUrl()
        {
            return new Uri($"http://{DockerHost()}:5000/picture");
        }

        private String DockerHost()
        {
            var variable = System.Environment.GetEnvironmentVariable("DOCKER_HOST");
            if (String.IsNullOrEmpty(variable))
            {
                return "localhost";
            }
            else
            {
                return new UriBuilder(variable).Host;
            }
        }
    }
}