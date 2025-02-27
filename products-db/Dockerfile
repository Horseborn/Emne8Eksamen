FROM mysql:8.0

# Set the MySQL root password as required
ENV MYSQL_ROOT_PASSWORD=securepass

# Copy SQL files to the MySQL entrypoint directory so they run on startup
COPY database_setup.sql /docker-entrypoint-initdb.d/
COPY user_privileges.sql /docker-entrypoint-initdb.d/

# Expose MySQL default port
EXPOSE 3306
