<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProVote.ascx.cs" Inherits="Controls_ProVote" %>

<div class="Wrap_Vote">
    <h3><span><a href="#">更多>></a></span><b>热点调查</b></h3>
    <div class="Box">            
        <h5>1.您觉得网站的风格可以吗？</h5>
        <ul>
            <li><input type="checkbox" name="checkbox" id="checkbox" /> 很好</li>
            <li><input type="checkbox" name="checkbox" id="checkbox" /> 好</li>
            <li><input type="checkbox" name="checkbox" id="checkbox" /> 一般</li>
            <li><input type="checkbox" name="checkbox" id="checkbox" /> 有待改善</li>
        </ul>
        <dl>
        <input type="submit" name="button" id="button" value="投票" class="btn" />
        <input type="submit" name="button" id="button" value="查看" class="btn" />
        </dl>
    </div>
    <div class="BottomEdge"></div>
</div>