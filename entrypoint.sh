#!bin/bash

# exit when any command fails
set -e

while [ "$1" != "" ]; do
    case $1 in
        -f | --filter)  shift
                        filter=$1
                        ;;
        * )             echo "Invalid param: $1"
                        exit 1
    esac
    shift
done

if [ -z "$filter" ]
then
      echo "\nStarting tests without filter"
      dotnet test QA.AcceptanceCriteria.Specs.dll
else
      echo "\nStarting tests with filter: $filter"
      dotnet test QA.AcceptanceCriteria.Specs.dll --filter "$filter"
fi

echo "\nStarting LivingDoc generation"
dotnet tool run livingdoc test-assembly QA.AcceptanceCriteria.Specs.dll -t TestExecution_*.json --output /mnt/out