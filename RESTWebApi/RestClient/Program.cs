using System.Text.Json;
using MyModels;

using HttpClient client = new HttpClient();
using HttpRequestMessage request = new HttpRequestMessage(
    HttpMethod.Get, "http://localhost:5184/api/people");

using HttpResponseMessage response = await client.SendAsync(request);

List<Person> people = JsonSerializer.Deserialize<List<Person>>(
    await response.Content.ReadAsStringAsync(),
    new JsonSerializerOptions{ PropertyNameCaseInsensitive = true }
);

foreach(var p in people)
    Console.WriteLine($"{p.Id}. {p.Name} - {p.Age}");
