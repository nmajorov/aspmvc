#!/usr/bin/env bash


IMAGE="docker.io/library/postgres:10"
#IMAGE="registry.centos.org/centos/postgresql-96-centos7"
#IMAGE="quay.io/centos7/postgresql-10-centos7:latest"
#IMAGE="registry.redhat.io/rhel8/postgresql-10"
#IMAGE="registry.redhat.io/rhscl/postgresql-10-rhel7"

#POD=sso
uid=$(id -u)
USER_ID=uid

SCRIPT_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" >/dev/null 2>&1 && pwd )"


if [ "x$POSTGRESQL_USER" = "x" ];then
  POSTGRESQL_USER="trader"
fi


if [ "x$POSTGRESQL_PASSWORD" = "x" ]; then
  POSTGRESQL_PASSWORD="trader"
fi


if [ "x$POSTGRESQL_DATABASE" = "x" ]; then
  POSTGRESQL_DATABASE="root"
fi



echo "using docker image: $IMAGE"
CMD="docker run -d -it  --name  postgresql-database \
     -e POSTGRES_USER=$POSTGRESQL_USER -e POSTGRES_PASSWORD=$POSTGRESQL_PASSWORD \
     -e POSTGRES_DB=$POSTGRESQL_DATABASE \
     -p 5432:5432 \
     $IMAGE"

echo $CMD
$CMD

echo "wait database to start"
sleep 5
echo "check connection"
docker exec  postgresql-database pg_isready

run_sql_imports() {

	echo "run sql imports"

	docker cp  $SCRIPT_DIR/export.sql postgresql-database:/tmp

	docker  exec postgresql-database bash -c "psql -U $POSTGRESQL_USER -d $POSTGRESQL_DATABASE  < /tmp/export.sql"

}

run_sql_imports
