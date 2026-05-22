# GitHub Copilot Instructions

## General rules
- Regardless of the language used in prompts, always generate code and comments in English.
- If required information or context is missing, ask clarifying questions instead of making assumptions.
- Do not proceed with implementation when the requirements are ambiguous.

## Unit testing rules
- Use xUnit for unit tests.
- Follow Microsoft's unit testing best practices:
  https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices

## Additional testing expectations
- Write clear, focused, and deterministic unit tests.
- Keep each test responsible for a single behavior.
- Use meaningful test names that describe the scenario and expected result.
- Avoid unnecessary dependencies and hidden side effects in tests.