import { ReactElement } from "react";
import styles from "../../styles/utils/Table.module.css"


export interface TableItem {
    content: {
        [key: string]: string | ReactElement;
    },
    onClick?: () => void;
}

export interface TableProps {
    tableItems: TableItem[]
}

const Table = ({ tableItems }: TableProps) => {


    if (tableItems.length === 0) return <table></table>

    const columns = Object.keys(tableItems[0].content);

    const tableHeader = <tr className={styles["header"]}>
        {
            columns.map(
                col => <th key={col}>
                    {col}
                </th>
            )
        }
    </tr>

    const tableRows = tableItems.map((item, itemIndex) => <tr className={styles["row"]} onClick={item.onClick} key={itemIndex}>
        {columns.map(col => <td key={itemIndex + col}>{item.content[col]}</td>)}
    </tr>)


    return (
        <table className={styles["table"]}>
            <thead>
                {tableHeader}
            </thead>
            <tbody>
                {tableRows}
            </tbody>
        </table>
    )
}



export default Table