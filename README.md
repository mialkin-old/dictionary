# Dictionary

1. Install Docker desktop on your computer.
2. Create somewhere a new folder where you will store dictionary database file.
3. Create inside your folder a docker-compose.yml file with the following text inside:

```yaml
version: "3.8"
services:
  dictionary:
    image: registry.gitlab.com/mialkin/dict-mialkin-ru:latest
    ports:
      - "5000:80"
    volumes:
      - .:/app/SQLite-files
    restart: unless-stopped
    environment:
      - ADMIN_USERNAME=admin
      - ADMIN_PASSWORD=password123
    container_name: dictionary
```

4\. Using command line tool navigate to your folder and run `docker-compose up -d` command:

```bash
cd /path/to/dictionary
docker compose up -d
```
5\. In web browser go to http://localhost:5000/login. Enter username and password from docker-compose.yml file to begin adding new words.
