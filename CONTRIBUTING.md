## Setting up the environment

To set up the repository, run:

```sh
$ ./scripts/bootstrap
$ ./scripts/build
```

This will install required dependencies and build the SDK.

## Modifying/Adding code

The SDK was first generated from the OpenAPI spec by Stainless and is now maintained by hand.
When the API changes, update the types and methods to match `https://vatsense.com/openapi.yaml`,
keeping the existing names so code that uses the SDK keeps working. Header comments in the files
still say they were generated; they are kept to keep the diff small.

## Using the repository from source

To use a local version of this library from source in another project, add it using a directory reference:

```sh
$ dotnet add reference /path/to/sdk/src/Vatsense
```

## Formatting and linting

```sh
$ ./scripts/format
$ ./scripts/lint
```

## Running tests

```sh
$ ./scripts/test
```
