#!/bin/bash
docker run -d -it -p 80:80 -v ~/SQLite-files:/app/SQLite-files	--rm --name dictionary mialkin/dictionary:2.0