build:
	dotnet build RealEstate.sln
start:
	dotnet run --project RealEstate.sln
nuget:
	nuget pack -NoDefaultExcludes -OutputDirectory nupkg
publish:
	dotnet publish --os linux --arch x64 -c Release --self-contained

# If facing memory issues:
reset-vm:
	wsl --shutdown wsl

# Docker compose with/without build
compose: # docker-compose up
	docker-compose -p="realestate-microservices" up

compose-build: # docker-compose up with build
	docker-compose -p="realestate-microservices" up --build

compose-down:
	docker-compose -f down

dcu: # docker-compose up
	docker-compose -p="realestate-microservices" up

dcd: # docker-compose down
	docker-compose -f down


#clear volumes to re-initialize the DB
clear-volumes:
	docker-compose down -v


# Start service alone
s-clients:   #9001
	docker-compose up db.clients db.messages util.rabbitmq api.clients

s-contracts: #9002
	docker-compose up db.contracts db.messages util.rabbitmq api.contracts

s-external:  #9003
	docker-compose up db.messages util.rabbitmq api.external

s-estates:   #9004
	docker-compose up db.estates db.messages util.rabbitmq api.estates --build

s-listings:  #9005
	docker-compose up db.listings db.messages util.rabbitmq api.listings

s-messaging: #9006
	docker-compose up db.messages util.rabbitmq api.messaging

s-utilities: #9007
	docker-compose up db.messages util.rabbitmq api.utilities



# Build-Start service alone
b-s-gateway:   #9000
	docker-compose up api-gateway --build
	
b-s-clients:   #9001
	docker-compose up db.clients db.messages util.rabbitmq api.clients --build

b-s-contracts: #9002
	docker-compose up db.contracts db.messages util.rabbitmq api.contracts --build

b-s-external:  #9003
	docker-compose up db.messages util.rabbitmq api.external --build

b-s-estates:   #9004
	docker-compose up db.estates db.messages util.rabbitmq api.estates --build

b-s-listings:  #9005
	docker-compose up db.listings db.messages util.rabbitmq api.listings --build

b-s-messaging: #9006
	docker-compose up db.messages util.rabbitmq api.messaging --build

b-s-utilities: #9007
	docker-compose up db.messages util.rabbitmq api.utilities --build


b-s-db:
	docker-compose up db.clients db.contracts db.estates db.listings --build
	
	

# Build service alone 
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
