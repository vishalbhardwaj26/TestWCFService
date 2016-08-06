#This is a test program around WCF service learning 
 - Create default service application
	  * Run it(open a client service dialog) or debug it(opened in browser):  both open as different interface.
 - User svcutil.exe to make Service1.cs (client proxy) and Output.congig (paste it in App.Config/Web.Config, if already present).
 - Use simple console application and use Service1 and config file to talk with service
 - Use another console application and add serviceReference, it automatically add config and Service proxy class.
 - Ways to call service from remote
	- Svcutil.exe/Add service reference and use Proxy class (Soap)
	- Using Http Client to call striaght Uri, not needed any reference (http rest)
	- Use WebChannelfactory to dynamically access http rest verbs or functions. (http rest). It needs atleast service contracts and data contracts defined at one place dll shared by client and server. This will be used. When client and server are in our control. ChannelFactory enables you to dynamically creating a proxy object based on the Service Contract alone. You do not require to explicitly generating a proxy class or manually define. This is helpful in scenario where your service address changes frequently or DataContract changes to newer version and as a client you have lot of references to those services. So after changes happens at service side, client must update proxy.
 - Create your own proxy derived from ClientBase<IService1>, IService1; or you can work with readymade proxy ChannelFactory<IService1>
	1. Both give you channel to work with same contract functions.
	2. It either needs shared dll contains Iservice and data contracts shared between client and server. OR
	3. You can define same service contract on client side with equivalence namespace. [ServiceContract(namespace=...]
	
 - Call service from remote PC
 	- Not edit web.config + use local IIS in “properties->web” to create virtual directory.
 	- Now even you can close all solution, when your PC is on, your service is on. Any changes in service file will be reflected inn IIS immediately, because Virtual directory points to project folder.
 	-  Issue Not resolved: both PC should be on same wifi, either on mobile or on home Wifi.
 	-  On remote PC: use browser http://192.168.1.3/TestWCFService/Service1.svc
 	-  SOAP:
 	- Now you can use either svcutil to create proxy and config file OR
 	- You can directly add as service refernce in your console app and type complete IP address with service1.svc to disocver, which would add proxy and changes the config file as well.
 - Call service using http request from remote PC (restful services)
	- Changes in config file to expose web http message
	- Changes in contract to define WebGet attribute
	- Now you can directly hit in browser with rest api “http://192.168.1.3/TestWCFService/Service1.svc/GetData?value=102”
	- Or you can use HttpClient with Uri without adding any service reference (not needed if you are using complete uri)
	- Using httpClient to post as well get using uri links without adding any service ref in client project.
	- Even if we don’t have data contract , we can make similar structure with required fields only to post as key value pair in json string to serialize. (see example)
	- And in return we can easily parse json string as key value pair to work.
