#!/bin/sh
echo -ne '\033c\033]0;Unnamed\a'
base_path="$(dirname "$(realpath "$0")")"
"$base_path/serverExport.x86_64" "$@"
