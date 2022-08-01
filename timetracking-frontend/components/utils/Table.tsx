import { ReactElement } from "react";
import styles from "../../styles/utils/Table.module.css"


export interface TableItem {
    [key: string]: string | ReactElement;
}

export interface TableProps {
    tableItems: TableItem[]
}

const Table = ({ tableItems }: TableProps) => {


    if (tableItems.length === 0) return <table></table>

    const columns = Object.keys(tableItems[0]);

    const tableHeader = <tr className={styles["header"]}>
        {
            columns.map(
                col => <th key={col}>
                    {col}
                </th>
            )
        }
    </tr>

    const tableRows = tableItems.map((item, itemIndex) => <tr key={itemIndex}>
        {columns.map(col => <td key={itemIndex + col}>{item[col]}</td>)}
    </tr>)


    return (
        <table className={styles["table"]}>
            {tableHeader}
            {tableRows}
        </table>
    )
}



export default Table