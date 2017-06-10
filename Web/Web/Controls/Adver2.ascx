<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Adver2.ascx.cs" Inherits="Controls_Adver2" %>
<style type="Text/css">
    div,p,a{margin:0px;padding:0px;}     
    .YFocus{position:relative;z-index:4;margin:15px auto;width:300px;height:200px;padding:4px;border:3px solid #B0BEC7;overflow:hidden; float:left;}
    .YImage,.YImage .YPhotos{margin:0 auto;overflow:hidden;width:300px;padding:0;}
    .YImage{position:relative;z-index:5;}
    .YImage,.YPhotos img{width:300px;height:200px;}
    .YPhotos{position:absolute;top:0;left:0;z-index:6;overflow:hidden;}
    .YPhotos img{float:left;clear:both;}
    .YFocus .YSamples{position:absolute;z-index:7;width:300px;height:63px;overflow:hidden;bottom:4px;left:4px;background-color:#000;opacity:.7;-moz-opacity:.7;filter:alpha(opacity=70);padding:0;}
    .YSamples a:link,.YSamples a:visited,.YSamples a:hover{position:relative;z-index:8;float:left;margin:10px 5px 8px 5px;display:inline;width:50px;height:43px;text-decoration:none;overflow:hidden;}
    .YSamples a img{border:2px solid #FFF;width:40px;height:30px;opacity:.4;-moz-opacity:.4;filter:alpha(opacity=40);}
    .YSamples a:hover img,.YSamples img.current{opacity:1;-moz-opacity:1;filter:alpha(opacity=100);}
</style>
<div class="YFocus">
     <div class="YImage">
          <p id="YPhotos" class="YPhotos">
   	         <a href="http://www.yaohaixiao.com/" title="听歌的美女"><img src="img/1.jpg" alt="听歌的美女" /></a>
             <a href="http://www.yaohaixiao.com/" title="名模写真"><img src="img/2.jpg" alt="名模写真" /></a>
             <a href="http://www.yaohaixiao.com/" title="极品红色法拉利跑车"><img src="img/3.jpg" alt="极品红色法拉利跑车" /></a>
             <a href="http://www.yaohaixiao.com/" title="空中特技表演"><img src="img/4.jpg" alt="空中特技表演" /></a>
             <a href="http://www.yaohaixiao.com/" title="混血美女 莉亚迪桑"><img src="img/5.jpg" alt="混血美女 莉亚迪桑" /></a>
           </p>
     </div>
     <p id="YSamples" class="YSamples">
        <a href="#1" class="current" title="听歌的美女"><img src="img/s-1.jpg" alt="听歌的美女" /></a>
        <a href="#1" title="名模写真"><img src="img/s-2.jpg" alt="名模写真" /></a>
        <a href="#1" title="极品红色法拉利跑车"><img src="img/s-3.jpg" alt="极品红色法拉利跑车" /></a>
        <a href="#1" title="空中特技表演"><img src="img/s-4.jpg" alt="空中特技表演" /></a>
        <a href="#1" title="混血美女 莉亚迪桑"><img src="img/s-5.jpg" alt="混血美女 莉亚迪桑" /></a>
     </p>
</div>
<script language="javascript" type="text/javascript"> 
<!--
(function(){
    YAO.YTabs({
        tabs: YAO.getEl('YSamples').getElementsByTagName('img'),
        contents: YAO.getEl('YPhotos').getElementsByTagName('img'),
        auto: true,
        scroll: true,
        scrollId: 'YPhotos'
    });
})();
//-->
</script>