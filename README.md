# Dictionary

1. Install [Docker Desktop](https://docs.docker.com/get-docker/) on your computer.
2. Create a new `dictionary` folder for storing application files:

```bash
cd
mkdir dictionary
```

3. In text editor create `docker-compose.yml` file with the following text:

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

Save that file to `dictionary` folder.

4\. Go to `dictionary` folder and run `docker-compose up -d` command:

```bash
cd
cd dictionary
docker compose up -d
```

5. Make sure that your container is up by running:

```bash
docker ps -a
```

6\. In your browser navigate to http://localhost:5000/login and enter username and password from docker-compose.yml file in order to log in to be able to add new words.
