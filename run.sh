#!/bin/bash
docker run -d --restart unless-stopped -it -p 5001:80 -v ~/SQLite-files:/app/SQLite-files -e ADMIN_PASSWORD=yourpass --name dictionary mialkin/dictionary:latest