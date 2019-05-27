using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using www.gzwulian.com.BLL;
using www.gzwulian.com.Common;
using www.gzwulian.com.Model;
using Menu = www.gzwulian.com.Model.Menu;

namespace ChargeWin
{
    public partial class frmSetRights : Form
    {
        private www.gzwulian.com.Model.Menu menuModel = new www.gzwulian.com.Model.Menu();
        private List<www.gzwulian.com.Model.Menu> menuModelList = new List<www.gzwulian.com.Model.Menu>();
        private MenuManager menuBLL = new MenuManager();
        private www.gzwulian.com.BLL.RightsGroupManager rolesBLL = new RightsGroupManager();
        private www.gzwulian.com.Model.RightsGroup rightsGroupModel = new RightsGroup();
        private DataTable dt = null;

        public frmSetRights(int id)
        {
            rightsGroupModel = rolesBLL.GetModel(id);
            InitializeComponent();
        }

        private void frmSetRights_Load(object sender, EventArgs e)
        {
            dt = menuBLL.GetAllList().Tables[0];
            BindRoles();
            //InitDictionary();
            //BindRights();
        }

        private Dictionary<int, bool> rights = null;

        private void InitDictionary()
        {
            rights = new Dictionary<int, bool>();
            //rights.Add();
            //角色名称
            string roleName = cbRoleList.Text;
            rightsGroupModel = GetModelByRoleName(roleName);
            if (rightsGroupModel!=null)
            {
                string groupRightsList = rightsGroupModel.GroupRightsList;
                string[] menuGroulist = groupRightsList.Split(';');
                //List<int> menulist = new List<int>();
                if (!string.IsNullOrEmpty(groupRightsList))
                {
                    for (int i = 0; i < menuGroulist.Length; i++)
                    {
                        string[] ids = menuGroulist[i].Split(',');
                        for (int j = 0; j < ids.Length; j++)
                        {
                            rights.Add(int.Parse(ids[j]), true);
                            //menulist.Add(int.Parse(ids[j]));
                        }
                    }
                }
            }
          

        }

        /// <summary>
        /// 绑定权限
        /// </summary>
        private void BindRights()
        {
            //禁用树视图的重绘
            tvRightsList.BeginUpdate();
            //清除原有节点
            tvRightsList.Nodes.Clear();
            Bind_Tv(dt, tvRightsList.Nodes, "0", "Id", "ParentId", "Name");
            // 展开所有树节点
            tvRightsList.ExpandAll();
            // 启用树视图的重绘
            tvRightsList.EndUpdate();
            //InitRights(); 

        }

        /// <summary>
        /// 绑定TreeView（利用TreeNodeCollection）
        /// </summary>
        /// <param name="tnc">TreeNodeCollection（TreeView的节点集合）</param>
        /// <param name="pid_val">父id的值</param>
        /// <param name="id">数据库 id 字段名</param>
        /// <param name="pid">数据库 父id 字段名</param>
        /// <param name="text">数据库 文本 字段值</param>
        private void Bind_Tv(DataTable dt, TreeNodeCollection tnc, string pid_val, string id, string pid, string text)
        {
            DataView dv = new DataView(dt); //将DataTable存到DataView中，以便于筛选数据
            TreeNode tn; //建立TreeView的节点（TreeNode），以便将取出的数据添加到节点中
            //以下为三元运算符，如果父id为空，则为构建“父id字段 is null”的查询条件，否则构建“父id字段=父id字段值”的查询条件
            string filter = string.IsNullOrEmpty(pid_val) ? pid + " is null" : string.Format(pid + "='{0}'", pid_val);
            dv.RowFilter = filter; //利用DataView将数据进行筛选，选出相同 父id值 的数据
            foreach (DataRowView drv in dv)
            {
                tn = new TreeNode(); //建立一个新节点（学名叫：一个实例）
                tn.Name = drv[id].ToString(); //节点的Value值，一般为数据库的id值
                tn.Text = drv[text].ToString(); //节点的Text，节点的文本显示
                if (rights.Keys.Contains(Convert.ToInt32(tn.Name)))
                {
                    if (rights[Convert.ToInt32(tn.Name)])
                    {
                        tn.Checked = true;
                    }
                }
                tnc.Add(tn); //将该节点加入到TreeNodeCollection（节点集合）中
                Bind_Tv(dt, tn.Nodes, tn.Name, id, pid, text); //递归（反复调用这个方法，直到把数据取完为止）
            }
        }


        /// <summary>
        /// 通过菜单名称得到菜单实体
        /// </summary>
        /// <param name="name">菜单名称</param>
        /// <returns></returns>
        private www.gzwulian.com.Model.Menu GetMenuByName(string name)
        {
            List<www.gzwulian.com.Model.Menu> menuModelList = new List<www.gzwulian.com.Model.Menu>();
            menuModel = menuBLL.GetModelList("Name=" + "'" + name + "'").First();
            return menuModel;
        }

        /// <summary>
        /// 通过菜单的父菜单Id获取子菜单列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private List<www.gzwulian.com.Model.Menu> GetChildMenusByParentId(int id)
        {

            menuModelList = menuBLL.GetModelList("ParentId=" + id);
            return menuModelList;

        }

        /// <summary>
        /// 绑定角色
        /// </summary>
        private void BindRoles()
        {
            DataSet ds = rolesBLL.GetAllList();
            cbRoleList.DisplayMember = "GroupName";
            cbRoleList.ValueMember = "GroupName";
            cbRoleList.DataSource = ds.Tables[0].DefaultView;
        

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbRoleList.Text=="管理员")
            {
                MessageHelper.ShowTips("不能修改管理员权限");
                return;
            }
            www.gzwulian.com.Model.RightsGroup chRightGroupModel = new RightsGroup();
            StringBuilder rights = new StringBuilder();
            //遍历节父点
            foreach (TreeNode parentNote in tvRightsList.Nodes)
            {
                //子节点有选中项
                if (IsChildChecked(parentNote))
                {
                    menuModel = GetModelByMenuName(parentNote.Text);
                    rights.Append(";" + menuModel.Id);
                    foreach (TreeNode tempnote in parentNote.Nodes)
                    {
                        if (tempnote.Checked == true)
                        {
                            menuModel = GetModelByMenuName(tempnote.Text);
                            rights.Append("," + menuModel.Id);
                        }
                    }
                }

            }
            rightsGroupModel.GroupRightsList = rights.ToString().Trim(';');
            if (rolesBLL.Update(rightsGroupModel))
            {
                MessageHelper.ShowTips("保存成功！");
                //InitRights();
            }
            else
            {
                MessageHelper.ShowTips("保存失败！");
            }
        }

        /// <summary>
        /// 子节点中是否有选中项
        /// </summary>
        /// <returns></returns>
        private bool IsChildChecked(TreeNode parentNode)
        {
            int flag = 0;
            foreach (TreeNode tempChild in parentNode.Nodes)
            {
                if (tempChild.Checked)
                {
                    flag = flag + 1;
                }
            }
            if (flag != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 通过角色名称获得角色实体
        /// </summary>
        /// <param name="name">角色名称</param>
        /// <returns></returns>
        private www.gzwulian.com.Model.RightsGroup GetModelByRoleName(string name)
        {
            rightsGroupModel = rolesBLL.GetModelList("GroupName=" + "'" + name + "'").First();
            return rightsGroupModel;
        }

        /// <summary>
        /// 通过菜单名称获得菜单实体
        /// </summary>
        /// <param name="name">菜单名称</param>
        /// <returns></returns>
        private www.gzwulian.com.Model.Menu GetModelByMenuName(string name)
        {
            menuModel = menuBLL.GetModelList("Name=" + "'" + name + "'").First();
            return menuModel;
        }

        /// <summary>
        /// 遍历子节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private TreeNode GetNode(TreeNode node)
        {
            if (node.Nodes.Count == 0)
            {
                return new TreeNode(node.Text);
            }
            TreeNode ns = new TreeNode(node.Text);
            foreach (TreeNode item in node.Nodes)
            {
                TreeNode n = GetNode(item);
                ns.Nodes.Add(n);
            }
            return ns;
        }

        private void cbRoleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRoleList.SelectedIndex > -1)
            {
                InitDictionary();
                BindRights();
                //if (cbRoleList.Text =="级超管理员")
                //{
                //    tvRightsList.Enabled = false;
                //}

                if (cbRoleList.Text == "超级管理员" || cbRoleList.Text == "管理员")
                {
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }

        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            frmAddRole frmaddrole = new frmAddRole();
            DialogResult dr = frmaddrole.ShowDialog();
            if (dr == DialogResult.OK)
            {
                BindRoles();
            }
        }

        /// <summary> 
        /// 根据子节点状态设置父节点的状态 
        /// </summary> 
        /// <param name="childNode"></param> 
        private void SetParentChecked(TreeNode childNode)
        {
            TreeNode parentNode = childNode.Parent;
            if (!parentNode.Checked && childNode.Checked)
            {
                int ichecks = 0;
                for (int i = 0; i < parentNode.GetNodeCount(false); i++)
                {
                    TreeNode node = parentNode.Nodes[i];
                    if (node.Checked)
                    {
                        ichecks++;
                    }
                }
                if (ichecks == parentNode.GetNodeCount(false))
                {
                    parentNode.Checked = true;
                    if (parentNode.Parent != null)
                    {
                        SetParentChecked(parentNode);
                    }
                }
            }
            else if (parentNode.Checked && !childNode.Checked)
            {
                parentNode.Checked = false;
            }
        }

        /// <summary> 
        /// 根据父节点状态设置子节点的状态 
        /// </summary> 
        /// <param name="parentNode"></param> 
        private void SetChildChecked(TreeNode parentNode)
        {
            for (int i = 0; i < parentNode.GetNodeCount(false); i++)
            {
                TreeNode node = parentNode.Nodes[i];
                node.Checked = parentNode.Checked;
                if (node.GetNodeCount(false) > 0)
                {
                    SetChildChecked(node);
                }
            }
        }

        private void tvRightsList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // 判断是否是根节点 
            SetChildChecked(e.Node);
            if (e.Node.Parent != null)
            {
                SetParentChecked(e.Node);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageHelper.ConfirmYesNo("确定要删除角色：" + "'" + cbRoleList.Text + "'"))
            {
                rightsGroupModel = rolesBLL.GetModelList("GroupName=" + "'" + cbRoleList.Text + "'").First();
                if (rightsGroupModel != null)
                {
                    rolesBLL.Delete(rightsGroupModel.Id);
                    BindRoles();
                }
            }

        }
    }
}

