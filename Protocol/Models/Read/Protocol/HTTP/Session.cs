using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;
using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    internal partial class HTTPSession : IRelationEvaluator, IHTTPSession
    {
        #region Get

        public IEnumerable<IParamsParam> GetLinkedParameters(RelationManager relationManager)
        {
            foreach (var link in relationManager.GetForwardLinks(this))
            {
                if (link.Target is IParamsParam param)
                {
                    yield return param;
                }
            }
        }

        #endregion

        #region IRelationEvaluator

        IEnumerable<Reference> IRelationEvaluator.GetRelations()
        {
            var username = this.UserName?.Value;
            if (Int32.TryParse(username, out _))
            {
                yield return new Reference(this, Mappings.ParamsById, username, this, isLogic: false, reverse: true);
            }

            var password = this.Password?.Value;
            if (Int32.TryParse(password, out _))
            {
                yield return new Reference(this, Mappings.ParamsById, password, this, isLogic: false, reverse: true);
            }

            foreach (HTTPSessionConnection c in this)
            {
                var req = c.Request;
                if (req != null)
                {
                    var id = req.Pid?.Value;
                    if (id != null)
                        yield return new Reference(this, Mappings.ParamsById, Convert.ToString(id), req);

                    var headers = req.Headers;
                    if (headers != null)
                    {
                        foreach (var h in headers)
                        {
                            var pid = h.Pid?.Value;
                            if (pid != null)
                                yield return new Reference(this, Mappings.ParamsById, Convert.ToString(pid), h);
                        }
                    }

                    var data = req.Data;
                    if (data != null)
                    {
                        var pid = data.Pid?.Value;
                        if (pid != null)
                            yield return new Reference(this, Mappings.ParamsById, Convert.ToString(pid), data);
                    }

                    var parameters = req.Parameters;
                    if (parameters != null)
                    {
                        foreach (var p in parameters)
                        {
                            var pid = p.Pid?.Value;
                            if (pid != null)
                                yield return new Reference(this, Mappings.ParamsById, Convert.ToString(pid), p);
                        }
                    }
                }

                var res = c.Response;
                if (res != null)
                {
                    var statusCode = res.StatusCode?.Value;
                    if (statusCode != null)
                        yield return new Reference(this, Mappings.ParamsById, Convert.ToString(statusCode), res);

                    var headers = res.Headers;
                    if (headers != null)
                    {
                        foreach (var h in headers)
                        {
                            var pid = h.Pid?.Value;
                            if (pid != null)
                                yield return new Reference(this, Mappings.ParamsById, Convert.ToString(pid), h);
                        }
                    }

                    var content = res.Content;
                    if (content != null)
                    {
                        var pid = content.Pid?.Value;
                        if (pid != null)
                            yield return new Reference(this, Mappings.ParamsById, Convert.ToString(pid), content);
                    }
                }
            }
        }

        #endregion

    }
}
