# WindowsClock
windows桌面股票工具  
一直没有找到一个很合适的桌面股票小工具，就利用业余时间自己开发一下，想要什么样的功能自己增加。
也觉得很有意义。

网上找了‘蓝光迷你股票’，界面非常不错，但是发现，一直在最上方，不是我想要的。  	

界面比较简单，但能满足要求，以后再完善。  

![界面](WindowsStockTool/image/main.png)


# 功能说明
1.可以增加自选股票。在安装目录下有一个xml文件。  
2.按右上角的按钮可移动窗体位置。位置可记录，下次启动自动显示在最后一次固定位置。  
3.右键菜单隐藏，可以隐藏股票列表，防止过往同事或者老板看到。  
4.可设置开机自动启动。  


## 如何增加自选股票
```xml
<?xml version="1.0" encoding="utf-8"?>
<ArrayOfMyStock xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    <MyStock>
        <type>sh</type>
        <code>000001</code>
        <name>上证指数</name>
    </MyStock>
    <MyStock>
        <type>sz</type>
        <code>399001</code>
        <name>深证指数</name>
    </MyStock>
</ArrayOfMyStock>
```

## 后续计划增加功能
1.显示更多的详细信息。  
2.点击列表某一项可以打开网页，显示最新情况。  
3.增加账户体系，自选信息保存在服务器。需要此功能的用户请留言，超过一定量则购买服务器增加。  


