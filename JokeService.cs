using System;
using System.Collections.Generic;

public class JokeService
{
  private static readonly List<Joke> _jokes = new List<Joke>();

  public Joke GetJoke()
  {
    if (_jokes.Count == 0)
    {
      // add several jokes to the list
      _jokes.Add(new Joke
      {
        Type = "programming",
        Setup = "Why do programmers always mix up Halloween and Christmas?",
        Punchline = "Because Oct 31 == Dec 25"
      });
      // Add another joke
      _jokes.Add(new Joke
      {
        Type = "programming",
        Setup = "How do you call a function named 'myFunction' on the myObject object?",
        Punchline = "myObject.myFunction()"
      });
      // Add a joke about powershell
      _jokes.Add(new Joke
      {
        Type = "programming",
        Setup = "Why did the PowerShell developer go broke?",
        Punchline = "Because he used up all his $s"
      });
      // Add a joke about java
      _jokes.Add(new Joke
      {
        Type = "programming",
        Setup = "Why did the Java developer quit his job?",
        Punchline = "Because he didn't get arrays."
      });
      // Add a joke about C#
      _jokes.Add(new Joke
      {
        Type = "programming",
        Setup = "Why did the C# developer fall asleep?",
        Punchline = "Because he didn't like Java."
      });

    }

    return _jokes[new Random().Next(0, _jokes.Count - 1)];
  }
}