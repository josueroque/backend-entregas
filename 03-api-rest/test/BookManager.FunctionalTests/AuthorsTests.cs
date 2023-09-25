using BookManager.Application.Models;
using System.Net.Http.Json;
using System.Text.Json;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using BookManager.IntegrationTests.TestSupport;

namespace Book.IntegrationTests;
public class MessagesTests
    : IntegrationTest
{
    [Fact]
    public async Task Given_Book_Creation_When_Getting_The_Book_Then_The_Book_Created_Is_Retrieved()
    {
        // Given

       var newAuthor = new AuthorModel { CountryCode = "HN", FirstName="TestName", LastName = "TestLastName" };

         var createAuthorResponse = await HttpClient.PostAsJsonAsync($"api/Author", newAuthor);

        if (!createAuthorResponse.IsSuccessStatusCode)
        {
            throw new Exception(createAuthorResponse?.ToString());
        }

        var createAuthorResponseText = await createAuthorResponse.Content.ReadAsStringAsync();

        int authorId =  int.Parse (createAuthorResponseText.Replace("\"", string.Empty));

        // When
        var result = await HttpClient.GetAsync($"api/Author/{authorId}");

        // Then
        var json = await result.Content.ReadAsStringAsync();
        var serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        var author = (JsonSerializer.Deserialize<AuthorModel>(json, serializerOptions)
                       ?? new AuthorModel ());

        author.FirstName.Should().Be("TestName");

        author.LastName.Should().Be("TestLastName");

        author.CountryCode.Should().Be("HN");


    }
}
