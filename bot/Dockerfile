FROM python:3.9.9-slim
WORKDIR /app
COPY requirements.txt .
RUN pip install -r requirements.txt

COPY src/ .
# -u is needed so printf is automatically flushed to docker logs output
CMD [ "python", "-u", "main.py" ]