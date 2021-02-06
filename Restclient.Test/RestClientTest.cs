using System.Net;
using System.Threading.Tasks;
using Restclient.Logic;
using Xunit;

namespace Restclient.Test
{
    public class RestClientTest
    {
        #region Test Get

        [Fact]
        public async Task Get_Ok()
        {
            var client = new RestClient();
            var response = await client.GetAsync<object>("https://jsonplaceholder.typicode.com/posts");

            Assert.NotNull(response.Response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        #endregion

        #region Test Post

        [Fact]
        public async Task Post_Ok()
        {
            var client = new RestClient();
            var response = await client.PostAsync<object>("https://jsonplaceholder.typicode.com/posts", new {});

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        #endregion

        #region Test Put

        [Fact]
        public async Task Put_Ok()
        {
            var client = new RestClient();
            var response = await client.PutAsync<object>("https://jsonplaceholder.typicode.com/posts/1", new {});

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        #endregion

        #region Test Delete

        [Fact]
        public async Task Delete_Ok()
        {
            var client = new RestClient();
            var response = await client.DeleteAsync<object>("https://jsonplaceholder.typicode.com/posts/1");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        #endregion
    }
}
