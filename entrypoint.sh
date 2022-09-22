#!bin/bash

# exit when any command fails
set -e

# set defaults
generateDoc=false
runTests=true

# map params
while [ "$1" != "" ]; do
    case $1 in
      -f | --filter)          shift
                              filter=$1
                              ;;
      -gd | --generate-doc)   shift
                              generateDoc=$1
                              ;;
      -rt | --run-tests)      shift
                              runTests=$1
                              ;;
      * )                     echo "Invalid param: $1"
                              exit 1
    esac
    shift
done

# run tests
if [ "$runTests" != false ]
then
      if [ -z "$filter" ]
      then
            echo "\nStarting tests without filter"
            dotnet test QA.AcceptanceCriteria.Specs.dll
      else
            echo "\nStarting tests with filter: $filter"
            dotnet test QA.AcceptanceCriteria.Specs.dll --filter "$filter"
      fi
fi

# generate doc
if [ "$generateDoc" = true ]
then
      echo "\nStarting LivingDoc generation"
      dotnet tool run livingdoc test-assembly QA.AcceptanceCriteria.Specs.dll -t /mnt/out/TestExecution_*.json --output /mnt/out
fi