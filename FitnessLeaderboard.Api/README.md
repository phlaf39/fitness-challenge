This is the 

To connect to Artifact Registry
```
gcloud auth configure-docker northamerica-northeast1-docker.pkg.dev
```

To build image
```
docker build -t northamerica-northeast1-docker.pkg.dev/project-466d0fc2-5aab-4df2-b87/fitness-leaderboard/fitness-leaderboard:latest .
```

push image

```
docker push northamerica-northeast1-docker.pkg.dev/project-466d0fc2-5aab-4df2-b87/fitness-leaderboard/fitness-leaderboard
```[Dockerfile](../Dockerfile)

Deploy Image
```
gcloud run deploy fitness-leaderboard --image northamerica-northeast1-docker.pkg.dev/project-466d0fc2-5aab-4df2-b87/fitness-leaderboard/fitness-leaderboard:latest --region northamerica-northeast1
```


http://www.strava.com/oauth/authorize?client_id=202136&response_type=code&redirect_uri=https://fitness-leaderboard-501636054852.northamerica-northeast1.run.app/auth-strava&approval_prompt=force&scope=read,read_all,profile:read_all,activity:read,activity:read_all
http://www.strava.com/oauth/authorize?client_id=202136&response_type=code&redirect_uri=https://fitness-leaderboard-501636054852.northamerica-northeast1.run.app/auth-strava123&approval_prompt=force&scope=read,read_all,profile:read_all,activity:read,activity:read_all
