#!/usr/bin/env zsh

# run psql in docker
docker exec -it postgresql-database bash -c "psql --username=trader  --dbname=root"

