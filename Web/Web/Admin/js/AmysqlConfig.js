/************************************************
 *
 * Amysql Framework
 * Amysql.com 
 * @param AmysqlConfig 系统配置
 *
 */
var _HttpPath = '';
var _ContentUrl = 'AmysqlContent.html';
var _TagUrl = 'AmysqlTag.html';			// AmysqlTag
var _LeftUrl = 'AmysqlLeft.html';		// AmysqlLeft
var _AmysqlContent;						// 框架内容
var _AmysqlTag;							// 框架标签
var _AmysqlLeft;						// 框架左栏
var _AmysqlContentLoad = false;
var _AmysqlTagLoad = false;
var _AmysqlLeftLoad = false;


// 设置默认打开的标签列表
//var _AmysqlTabJson = [
//	//{'type':'Activate','id':'Amysql AMF','name':'AMYSQL Framework', 'url':'Default.aspx'},
//	{'type':'Normal','id':'AmysqlHome','name':'Amysql Home', 'url':'main.aspx'}//,
//	//{'type':'Normal','id':'SetAmysql','name':'Amysql System', 'url':'AmysqlSystem.html'}
//];

// 设置默认小标签列表
var _AmysqlTabMinJson = [];


// 设置左栏下拉菜单数据
var _AmysqlLNIJson = [
//	{'order':6.1,'id':'SetTemplet', 'name':'AmysqlTemplet.html', 'url':'AmysqlTemplet.html'}, 
//	{'order':6.2,'id':'SetAmysql', 'name':'System.html', 'url':'AmysqlSystem.html'}, 
//	{'order':7,'id':'SetAmysqlWeb', 'name':'Amysql.com', 'url':'http://amysql.com'}, 
];

// 设置左栏列表数据
//var _AmysqlLeftListJson = [
//{'id':'MyTable','name':'Amysql MyTable','url':'SystemModel/Product/ProductList.aspx?MyTable','IcoClass':'ico_database','open':true,'ChildItem':[
//	{'id':'MyUser','name':'MyUser','url':'SystemModel/Product/ProductList.aspx?MyUser','IcoClass':'ico_tabel','ChildItem':null},
//	{'id':'MyAddress','name':'MyAddress','url':'SystemModel/Product/ProductList.aspx?MyAddress','IcoClass':'ico_tabel','ChildItem':null},
//	{'id':'MyLog','name':'MyLog','url':'SystemModel/Product/ProductList.aspx?MyLog','IcoClass':'ico_tabel','open':true,'ChildItem':[
//		{'id':'MyLog2009','name':'MyLog MyLog2009','url':'SystemModel/Product/ProductList.aspx?MyLog2009','IcoClass':'ico_tabel','ChildItem':null},
//		{'id':'MyLog2011','name':'MyLog MyLog2011','url':'SystemModel/Product/ProductList.aspx?MyLog2011','IcoClass':'ico_tabel','open':false,'ChildItem':[
//			{ 'id': '2011-02', 'name': '2011-02', 'url': 'SystemModel/Product/ProductList.aspx?2011-02', 'IcoClass': 'ico_tabel', 'ChildItem': null },
//			{'id':'2011-03','name':'2011-03','url':'SystemModel/Product/ProductList.aspx?2011-03','IcoClass':'ico_tabel','ChildItem':null},
//			{'id':'2011-07','name':'2011-07','url':'SystemModel/Product/ProductList.aspx?2011-07','IcoClass':'ico_tabel','ChildItem':null}
//		]},
//		{'id':'MyLog2012','name':'MyLog MyLog2012','url':'SystemModel/Product/ProductList.aspx?MyLog2012','IcoClass':'ico_tabel','ChildItem':null}
//		]}
//	]
//},
//{'id':'TestTree','name':'TestTree','url':'SystemModel/Product/ProductList.aspx?TestTree','IcoClass':'ico_database','ChildItem':null},
//{'id':'information_schema','name':'information_schema','url':'SystemModel/Product/ProductList.aspx?information_schema','IcoClass':'ico_tabel','open':true,'ChildItem':[
//	{'id':'CHARACTER_SETS','name':'CHARACTER_SETS','url':'SystemModel/Product/ProductList.aspx?CHARACTER_SETS','IcoClass':'ico_tabel','ChildItem':null},
//	{'id':'TABLES','name':'TABLES','url':'SystemModel/Product/ProductList.aspx?TABLES','IcoClass':'ico_tabel','ChildItem':null},
//	{'id':'COLLATIONS','name':'COLLATIONS','url':'SystemModel/Product/ProductList.aspx?COLLATIONS','IcoClass':'ico_tabel','ChildItem':null}
//]}
//];