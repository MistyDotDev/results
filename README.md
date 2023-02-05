# 💯 Results

## ❓ About

A collection of result types which are lightweight and simple to use.

## 📝 Installing

Results is delivered as a [NuGet](https://www.nuget.org/packages/MistyDotDev.Results) package.
It also follows the [SemVer](https://semver.org/) versioning scheme.
To add the package to your project, run the following command:

```
dotnet add package MistyDotDev.Results
```

## 📓 Examples

There are three `Result` types:

- No Value (`Result`)
- Value/Error (`Result<TValue>`)
- Value & Error (`Result<TError, TValue>`)

To facilitate flexibility, generics are heavily used.
This means that you can use any type you want for the value or error.

#### No Value

This is the simplest form of a `Result`.
It's just a wrapper around the `ResultStatus` enum.

```csharp
public Result DoSomethingIncredible()
{
    // Imagine some amazing code here.
    return Result.Success();
}

public void Main()
{
    var result = DoSomethingIncredible();
    if (result.IsFailure)
        Console.Out.WriteLine("Uh oh! The incredible thing didn't happen :(");

    Console.Out.WriteLine("Wow... That was incredible!");
}
```

#### Value/Error

This result type allows you to provide a value for either of the outcomes.

```csharp
public Result<APIError> DeleteDocumentById(long id)
{
    try
    {
        _api.Delete(id);
        return Result<APIError>.Success();
    }
    catch (Exception e)
    {
        return Result<APIError>.Failure(new APIError(e));
    }
}

public void Main()
{
    var result = DeleteDocumentById(123456789);
    if (result.IsFailure)
    {
        Console.Out.WriteLine($"Failed to delete the document! Reason {result.Error.Reason}");
        return;
    }

    Console.Out.WriteLine($"Deleted the document!");
}
```

#### Value & Error

This result type allows you to provide a value for each outcome.

```csharp
public Result<string, int> AddPositiveNumbers(int num1, int num2)
{
    if (num1 < 0 || num2 < 0)
        return Result<string, int>.Failure("One of the numbers isn't positive!");

    return Result<string, int>.Success(num1 + num2);
}

public void Main()
{
    var result = AddPositiveNumbers(-1, 20);
    if (result.IsFailure)
    {
        Console.Out.WriteLine(result.Error);
        return;
    }

    Console.Out.WriteLine($"The sum is {result.Value}");
}
```

## 🧑‍💻 Developing

To start developing Results, make sure you have the following installed:

- [.NET SDK 6](https://dotnet.microsoft.com/en-us/download)

Then open the solution in your favourite editor, or use the CLI to build:

```
dotnet build
```

## 🏗️ Deploying



To publish a new package, create a GitHub Release.
This will trigger a workflow which will build and upload a package.
The name of the release will be used as a version number.
