using System.IO;
using System.Web.Mvc;

namespace Marquite.Core
{
    public interface IMarquite
    {
        string GenerateNewId();
        string GenerateNewFormId();
        TextWriter GetTopmostWriter();
        IMarquite Global { get; }
        bool IsGlobal { get; }
        string GenerateId(string name);
        T ResolvePlugin<T>() where T : IMarquitePlugin, new();
        ViewContext ViewContext { get; }
        MarquiteEventsManager EventsManager { get; }
        ScopeManager ScopeManager { get; }
    }
}