#!/usr/bin/env bash
SCRIPT_DIR=`dirname "$0"`
#echo $SCRIPT_DIR
docker exec   postgresql-database  pg_dump -d root -U trader \
--schema=public --clean --attribute-inserts --if-exists  > $SCRIPT_DIR/$(date +%F-%H-%M)-full-export.sql
