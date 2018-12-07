${PORT}=5001
docker build -t cs-api-demo-builder-image --file ./docker/local-builder.dockerfile .
echo ""
echo ""
echo "********"
echo ""
echo "type 'run' to rebuild and start the app"
${msg} = "your local machine will be listening on the port :" + ${PORT}
echo ${msg}
echo "press ^C to stop the app"
echo "type 'exit' to leave and destroy the container"
echo ""
docker run -it --rm --name api-builder -v ${PWD}:/app -p ${PORT}:5555 cs-api-demo-builder-image
