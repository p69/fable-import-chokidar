namespace Fable.Import
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

module Chokidar =
    type [<AllowNullLiteral>] IOptions =
        abstract ignored: obj option with get, set
        abstract persistent: bool option with get, set
        abstract ignorePermissionErrors: bool option with get, set
        abstract ignoreInitial: bool option with get, set
        abstract interval: float option with get, set
        abstract binaryInterval: float option with get, set
        abstract usePolling: bool option with get, set
        abstract useFsEvents: bool option with get, set
        abstract followSymlinks: bool option with get, set
        abstract disableGlobbing: bool option with get, set

    and [<AllowNullLiteral>] FSWatcher =
        abstract options: IOptions with get, set
        abstract add: fileDirOrGlob: string -> unit
        abstract add: filesDirsOrGlobs: ResizeArray<string> -> unit
        abstract unwatch: fileDirOrGlob: string -> unit
        abstract unwatch: filesDirsOrGlobs: ResizeArray<string> -> unit
        abstract on: ``event``: string * clb: Func<string, string, unit> -> unit
        abstract on: ``event``: string * clb: Func<Error, unit> -> unit
        abstract close: unit -> unit

    type [<Import("*","chokidar")>] Globals =
        static member watch(paths: string, options: IOptions): FSWatcher = jsNative


