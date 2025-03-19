#! /bin/bash

TODAY=$(date +'%Y-%m-%d-%H:%M:%S')

dotnet ef migrations script --idempotent --verbose --output ./db-scripts/${TODAY}_migration.sql
