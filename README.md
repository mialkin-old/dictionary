# Dictionary

1. Install Docker desktop on your computer.
2. Create a new folder for storing dictionary files.
3. Inside the folder create a docker-compose.yml file with the following text inside:

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

4\. In command line navigate to the folder and run `docker-compose up -d` command:

```bash
cd /path/to/dictionary
docker compose up -d
```
5\. Navigate to http://localhost:5000/login and enter username and password from docker-compose.yml file in order to log in to be able to add new words.
