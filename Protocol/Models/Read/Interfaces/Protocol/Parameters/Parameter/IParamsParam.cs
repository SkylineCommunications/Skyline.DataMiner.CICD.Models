namespace Skyline.DataMiner.CICD.Models.Protocol.Read
{
    using System.Collections.Generic;

    using Skyline.DataMiner.CICD.Models.Protocol.Read.Linking;

    public partial interface IParamsParam
    {
        #region Is[Type]

        /// <summary>
        /// Determines whether this parameter is read / read bit.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter is read; otherwise, <c>false</c>.
        /// </returns>
        bool IsRead();

        /// <summary>
        /// Determines whether this parameter is write / write bit.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter is write; otherwise, <c>false</c>.
        /// </returns>
        bool IsWrite();

        #endregion

        #region Is[MeasurementType]

        /// <summary>
        /// Determines whether this instance is button.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter is button; otherwise, <c>false</c>.
        /// </returns>
        bool IsButton();

        /// <summary>
        /// Determines whether this instance is a context menu.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter is context menu; otherwise, <c>false</c>.
        /// </returns>
        bool IsContextMenu();

        /// <summary>
        /// Determines whether this instance is a parameter allowing to show dynamic QAction feedback.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter is used for QAciton feedback; otherwise, <c>false</c>.
        /// </returns>
        bool IsQActionFeedback();

        /// <summary>
        /// Determines whether this instance is pagebutton.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter is pagebutton; otherwise, <c>false</c>.
        /// </returns>
        bool IsPageButton();

        /// <summary>
        /// Determines whether this parameter is title.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter is title; otherwise, <c>false</c>.
        /// </returns>
        bool IsTitle();

        /// <summary>
        /// Determines whether this parameter is title begin.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter is title begin; otherwise, <c>false</c>.
        /// </returns>
        bool IsTitleBegin();

        /// <summary>
        /// Determines whether this parameter is title end.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter is title end; otherwise, <c>false</c>.
        /// </returns>
        bool IsTitleEnd();

        /// <summary>
        /// Determines whether this parameter is number.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter is number; otherwise, <c>false</c>.
        /// </returns>
        bool IsNumber();

        /// <summary>
        /// Determines whether this parameter is a datetime parameter.
        /// This will check if the parameter has the option 'date', 'datetime' or 'datetime:minute'.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter is a datetime parameter; otherwise, <c>false</c>.
        /// </returns>
        bool IsDateTime();

        /// <summary>
        /// Determines whether this parameter is time parameter.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter is time parameter; otherwise, <c>false</c>.
        /// </returns>
        bool IsTime();

        /// <summary>
        /// Determines whether this parameter is progress.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter is progress; otherwise, <c>false</c>.
        /// </returns>
        bool IsProgress();

        /// <summary>
        /// Determines whether this parameter is analog.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter is analog; otherwise, <c>false</c>.
        /// </returns>
        bool IsAnalog();

        /// <summary>
        /// Determines whether this parameter is string.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter is string; otherwise, <c>false</c>.
        /// </returns>
        bool IsString();

        #endregion

        #region TryGet

        /// <summary>
        /// Tries to get the table associated to this column (handling all read, write and read-write column).
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <param name="table">The table.</param>
        /// <returns>True if succeeded, false if not part of table.</returns>
        bool TryGetTableFromReadAndWrite(RelationManager relationManager, out IParamsParam table);

        /// <summary>
        /// Tries to get the table associated to this column. (only handling read and write columns but not read-write columns)
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <param name="table">The table.</param>
        /// <returns>True if succeeded, false if not part of table.</returns>
        bool TryGetTable(RelationManager relationManager, out IParamsParam table);

        /// <summary>
        /// Tries to get the (view) table associated to this (view) table column. (only handling read and write columns but not read-write columns)
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <param name="viewColumnPid">The id of the view column.</param>
        /// <param name="table">The table.</param>
        /// <returns>True if succeeded, false if not part of table.</returns>
        bool TryGetTable(RelationManager relationManager, uint viewColumnPid, out IParamsParam table);

        /// <summary>
        /// Gets the tables associated to this column.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>Table parameters referring to this column.</returns>
        IEnumerable<IParamsParam> GetTables(RelationManager relationManager);

        /// <summary>
        /// Gets the (view) tables associated to this (view) table column.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <param name="viewColumnPid">The id of the view column.</param>
        /// <returns>Table parameters referring to this column.</returns>
        IEnumerable<IParamsParam> GetTables(RelationManager relationManager, uint viewColumnPid);

        /// <summary>
        /// Tries to get the columns of a table.
        /// </summary>
        /// <param name="columns">List of columns previously retrieved using the GetColumns method.</param>
        /// <param name="idx">The idx of the column to be retrieved.</param>
        /// <param name="columnParam">The column corresponding to the given <paramref name="idx"/>.</param>
        /// <returns><see langword="true"/> if the column was found. <see langword="false"/> otherwise.</returns>
        bool TryGetColumn(IEnumerable<(uint? idx, string pid, IParamsParam columnParam)> columns, uint idx, out IParamsParam columnParam);

        /// <summary>
        /// Tries to get the columns of a table.
        /// </summary>
        /// <param name="columns">List of columns previously retrieved using the GetColumns method.</param>
        /// <param name="pid">The Param ID of the column to be retrieved.</param>
        /// <param name="columnParam">The column corresponding to the given <paramref name="pid"/>.</param>
        /// <returns><see langword="true"/> if the column was found. <see langword="false"/> otherwise.</returns>
        bool TryGetColumn(IEnumerable<(uint? idx, string pid, IParamsParam columnParam)> columns, string pid, out IParamsParam columnParam);

        /// <summary>
        /// Gets the columns of a table.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <param name="returnBaseColumnsIfDuplicateAs">In case columns are defined via duplicateAs (viewTables), chose if base columns should be returned or not.</param>
        /// <returns>The columns of the table.</returns>
        IEnumerable<(uint? idx, string pid, IParamsParam columnParam)> GetColumns(RelationManager relationManager, bool returnBaseColumnsIfDuplicateAs);

        /// <summary>
        /// Tries to get the write parameter.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <param name="writeParameter">The write parameter.</param>
        /// <returns>True if succeeded, false if parameter doesn't have a write parameter.</returns>
        bool TryGetWrite(RelationManager relationManager, out IParamsParam writeParameter);

        /// <summary>
        /// Tries to get the read parameter.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <param name="readParameter">The read parameter.</param>
        /// <returns>True if succeeded, false if parameter doesn't have a read parameter.</returns>
        bool TryGetRead(RelationManager relationManager, out IParamsParam readParameter);

        /// <summary>
        /// Get the columns with indexColumn option defined in ColumnOption@options attribute.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>The list of columns for which the indexColumn option is defined.</returns>
        IEnumerable<(uint? idx, string pid, IParamsParam columnParam)> GetIndexColumns(RelationManager relationManager);

        /// <summary>
        /// Tries to get the Primary Key column of the table.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <param name="primaryKeyColumn">The index column.</param>
        /// <returns>True if succeeded, false if not part of table.</returns>
        bool TryGetPrimaryKeyColumn(RelationManager relationManager, out IParamsParam primaryKeyColumn);

        #endregion

        /// <summary>
        /// Determines whether this instance is TreeControl.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>
        ///   <c>true</c> if the specified parameter is TreeControl; otherwise, <c>false</c>.
        /// </returns>
        bool IsTreeControl(RelationManager relationManager);

        /// <summary>
        /// Gets the RTDisplay of this parameter.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter has RTDisplay tag set to true; otherwise, <c>false</c>.
        /// </returns>
        bool GetRTDisplay();

        /// <summary>
        /// Determines whether the specified parameter is in SLElement. (RTDisplay == True)
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>
        ///   <c>true</c> if the specified parameter is in SLElement; otherwise, <c>false</c>.
        /// </returns>
        bool IsInSLElement(RelationManager relationManager);

        /// <summary>
        /// Gets the dependency identifier parameters.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>IEnumerable with parameters.</returns>
        ICollection<IParamsParam> GetDependencyIdParams(RelationManager relationManager);

        /// <summary>
        /// Determines whether the specified parameter is displayed.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>
        ///   <c>true</c> if the specified parameter is displayed; otherwise, <c>false</c>.
        /// </returns>
        bool IsDisplayed(RelationManager relationManager);

        /// <summary>
        /// Determines whether the specified parameter is positioned.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>
        ///   <c>true</c> if the specified parameter is positioned; otherwise, <c>false</c>.
        /// </returns>
        bool IsPositioned(RelationManager relationManager);

        /// <summary>
        /// Gets the diplicateAs IDs.
        /// </summary>
        IEnumerable<string> GetDuplicateAsIds();

        /// <summary>
        /// Determines whether this parameter will be exported.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter will be exported; otherwise, <c>false</c>.
        /// </returns>
        bool WillBeExported();

        /// <summary>
        /// Determines whether this parameter has a position.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter has a position; otherwise, <c>false</c>.
        /// </returns>
        bool HasPosition();

        /// <summary>
        /// Determines whether this parameter is a table.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter is a table; otherwise, <c>false</c>.
        /// </returns>
        bool IsTable();

        /// <summary>
        /// Determines whether this parameter is a logger table.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter is a logger table; otherwise, <c>false</c>.
        /// </returns>
        bool IsLoggerTable();

        /// <summary>
		/// Determines whether this parameter is a subtable.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter is a subtable; otherwise, <c>false</c>.
        /// </returns>
        bool IsSubtable();

        /// <summary>
        /// Determines whether this parameter is a matrix.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if the specified parameter is a matrix; otherwise, <c>false</c>.
        /// </returns>
        bool IsMatrix();

        /// <summary>
        /// Gets the dependency reference parameters. Most case this will be the button that contains this parameter inside it's Dependencies Tag.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>Collection of the Parameters that reference this parameter as Dependency.</returns>
        ICollection<IParamsParam> GetDependencyReferenceParameters(RelationManager relationManager);

        /// <summary>
        /// Gets the dependency parameters from this reference parameter. Most case this will be the dependencies of the button.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>Dependency Parameters from the reference Parameter.</returns>
        ICollection<IParamsParam> GetDependencyParameters(RelationManager relationManager);

        /// <summary>
        /// Gets the commands associated to this parameter.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>A collection of commands that contains this parameter.</returns>
        IEnumerable<ICommandsCommand> GetCommands(RelationManager relationManager);

        /// <summary>
        /// Gets the responses associated to this parameter.
        /// </summary>
        /// <param name="relationManager">The relation manager.</param>
        /// <returns>A collection of responses that contains this parameter.</returns>
        IEnumerable<IResponsesResponse> GetResponses(RelationManager relationManager);
    }
}