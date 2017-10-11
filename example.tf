/* transpiled with BefunCompile v1.1.0 (c) 2015 */

program Befunge
    global
        int tmp;
        int tmp2;
        char tmpc;
        stack<int>[16384] gis;
        int t0;
        int t1;
    begin
        gis.Push(1);
        gis.Push(2);
        gis.Push(2);
    _1:
        gis.Push(sr());
        t0=((int)(sr()/5))*5;
        gis.Push(sp()-t0);

        t1=sp();
        t1=(int)((t1)==0);

        if((t1)!=0)then
            goto _2;
        else
            goto _3;
        end
    _2:
        gis.Push(sr());
    _3:
        if(sr()-(1000)==0)then
            goto _5;
        else
            goto _4;
        end
    _4:
        sp();
        gis.Push(sp()+1);

        gis.Push(sr());
        gis.Push(sr());
        t0=((int)(sr()/3))*3;
        gis.Push(sp()-t0);

        t1=sp();
        t1=(int)((t1)==0);

        if((t1)!=0)then
            goto _2;
        else
            goto _1;
        end
    _5:
        sp();
        sp();
        sp();
    _6:
        gis.Push(sp()+sp());

        tmp=sp();
        tmp2=sp();
        gis.Push(tmp);
        gis.Push(tmp2);


        if(sr()-(1)==0)then
            goto _7;
        else
            goto _8;
        end
    _7:
        sp();
        out (int)sp();
        stop;
    _8:
        tmp=sp();
        tmp2=sp();
        gis.Push(tmp);
        gis.Push(tmp2);
        goto _6;
    end

int sp()
begin
    if (gis.Empty()) then return 0; end
    return gis.Pop();
end

int sr()
begin
    if (gis.Empty()) then return 0; end
    return gis.Peek();
end
end
