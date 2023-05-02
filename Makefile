build:
	dotnet build RealEstate.sln
start:
	dotnet run --project RealEstate.sln
nuget:
	nuget pack -NoDefaultExcludes -OutputDirectory nupkg
publish:
	dotnet publish --os linux --arch x64 -c Release --self-contained

compose: # docker-compose up
	docker-compose -p="realestate-microservices" up
compose-build: # docker-compose up
	docker-compose -p="realestate-microservices" up --build
dcu: # docker-compose up
	docker-compose -p="realestate-microservices" up
dcd: # docker-compose down
	docker-compose -f down

build-clients-ms:
	docker build -t clients.api -f Microservices/ClientsMicroservice/Dockerfile Microservices/ClientsMicroservice

build-contracts-ms:
	docker build -t contracts.api -f Microservices/ContractsMicroservice/Dockerfile Microservices/ContractsMicroservice

build-estates-ms:
	docker build -t estates.api -f Microservices/EstatesMicroservice/Dockerfile Microservices/EstatesMicroservice

build-external-ms:
	docker build -t external.api -f Microservices/ExternalAPIsMicroservice/Dockerfile Microservices/ExternalAPIsMicroservice

build-listings-ms:
	docker build -t listings.api -f Microservices/ListingsMicroservice/Dockerfile Microservices/ListingsMicroservice



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
