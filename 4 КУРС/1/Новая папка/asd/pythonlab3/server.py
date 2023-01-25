from xmlrpc.server import SimpleXMLRPCServer
import module

HOST = "localhost"
PORT = 8000

with SimpleXMLRPCServer((HOST, PORT)) as server:
    server.register_function(module.CountCharacters)
    server.register_function(module.CountLines)
    server.register_function(module.CountWords)
    server.register_function(module.CountOfCcurrences)
    server.register_function(module.CountNumbers)

    print(f"Listening on port {PORT}...")
    server.serve_forever()