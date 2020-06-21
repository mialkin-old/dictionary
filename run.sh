#!/bin/bash
docker run -d --restart unless-stopped -it -p 5001:80 -v ~/SQLite-files:/app/SQLite-files --name dictionary mialkin/dictionary:2.0