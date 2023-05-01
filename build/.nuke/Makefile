build:
	dotnet build RealEstate.sln
start:
	dotnet run --project RealEstate.sln
nuget:
	nuget pack -NoDefaultExcludes -OutputDirectory nupkg
publish:
	dotnet publish --os linux --arch x64 -c Release --self-contained

dcu: # docker-compose up
	docker-compose up
dcd: # docker-compose down
	docker-compose -f down


gw: # git docker workflow to push docker image to the repository based on the main branch
	@echo triggering github workflow to push docker image to container
	@echo ensure that you have the gh-cli installed and authenticated.
	gh workflow run dotnet-cicd -f push_to_docker=true




# Miscelanious commands - Terraform, AWS ECS
#tp: # terraform plan
#	cd terraform/environments/staging && terraform plan
#ta: # terraform apply
#	cd terraform/environments/staging && terraform apply
#td: # terraform destroy
#	cd terraform/environments/staging && terraform destroy
#fds: # force rededeploy aws ecs service
#	aws ecs update-service --force-new-deployment --service dotnet-webapi --cluster testcluster
#publish-to-hub:
#	dotnet publish --os linux --arch x64 -c Release -p:ContainerRegistry=docker.io -p:ContainerImageName=ivaaak/RealEstate --self-contained
